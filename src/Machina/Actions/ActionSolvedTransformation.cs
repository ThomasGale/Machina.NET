using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machina
{
    //  ████████╗██████╗  █████╗ ███╗   ██╗███████╗███████╗ ██████╗ ██████╗ ███╗   ███╗ █████╗ ████████╗██╗ ██████╗ ███╗   ██╗
    //  ╚══██╔══╝██╔══██╗██╔══██╗████╗  ██║██╔════╝██╔════╝██╔═══██╗██╔══██╗████╗ ████║██╔══██╗╚══██╔══╝██║██╔═══██╗████╗  ██║
    //     ██║   ██████╔╝███████║██╔██╗ ██║███████╗█████╗  ██║   ██║██████╔╝██╔████╔██║███████║   ██║   ██║██║   ██║██╔██╗ ██║
    //     ██║   ██╔══██╗██╔══██║██║╚██╗██║╚════██║██╔══╝  ██║   ██║██╔══██╗██║╚██╔╝██║██╔══██║   ██║   ██║██║   ██║██║╚██╗██║
    //     ██║   ██║  ██║██║  ██║██║ ╚████║███████║██║     ╚██████╔╝██║  ██║██║ ╚═╝ ██║██║  ██║   ██║   ██║╚██████╔╝██║ ╚████║
    //     ╚═╝   ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝╚══════╝╚═╝      ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚═╝  ╚═╝   ╚═╝   ╚═╝ ╚═════╝ ╚═╝  ╚═══╝
    //                                                                                                                         
    /// <summary>
    /// An Action representing a combined Translation and Rotation Transformation.
    /// USING Referenced tool and workobject actions (rather than internal tool rep).
    /// </summary>
    public class ActionSolvedTransformation : Action
    {
        public Vector translation;
        public Rotation rotation;
        public int Cf1, Cf4, Cf6, Cfx;

        public override ActionType Type => ActionType.SolvedTransformation;

        public ActionSolvedTransformation(double x, double y, double z, double vx0, double vx1, double vx2, double vy0,
            double vy1, double vy2, int cf1, int cf4, int cf6, int cfx) : base()
        {
            this.translation = new Vector(x, y, z);
            this.rotation = new Orientation(vx0, vx1, vx2, vy0, vy1, vy2);
            Cf1 = cf1;
            Cf4 = cf4;
            Cf6 = cf6;
            Cfx = cfx;
        }

        public ActionSolvedTransformation(Vector translation, Rotation rotation, int cf1, int cf4, int cf6, int cfx) : base()
        {
            this.translation = new Vector(translation);  // shallow copy
            this.rotation = new Rotation(rotation);  // shallow copy
            Cf1 = cf1;
            Cf4 = cf4;
            Cf6 = cf6;
            Cfx = cfx;
        }

        public override string ToString()
        {
            return string.Format("Transform: move to {0} mm and rotate to {1} with config [{2},{3},{4},{5}]", translation, new Orientation(rotation), Cf1, Cf4, Cf6, Cfx);
        }

        public override string ToInstruction()
        {
            Orientation ori = new Orientation(this.rotation);

            return string.Format("TransformTo({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12});",
                    Math.Round(this.translation.X, Geometry.STRING_ROUND_DECIMALS_MM),
                    Math.Round(this.translation.Y, Geometry.STRING_ROUND_DECIMALS_MM),
                    Math.Round(this.translation.Z, Geometry.STRING_ROUND_DECIMALS_MM),
                    Math.Round(ori.XAxis.X, Geometry.STRING_ROUND_DECIMALS_MM),
                    Math.Round(ori.XAxis.Y, Geometry.STRING_ROUND_DECIMALS_MM),
                    Math.Round(ori.XAxis.Z, Geometry.STRING_ROUND_DECIMALS_MM),
                    Math.Round(ori.YAxis.X, Geometry.STRING_ROUND_DECIMALS_MM),
                    Math.Round(ori.YAxis.Y, Geometry.STRING_ROUND_DECIMALS_MM),
                    Math.Round(ori.YAxis.Z, Geometry.STRING_ROUND_DECIMALS_MM),
                    Cf1,
                    Cf4,
                    Cf6, 
                    Cfx
                );
        }
    }
}
