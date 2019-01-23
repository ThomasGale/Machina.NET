using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machina
{
    //  ██████╗ ███████╗██████╗ 
    //  ██╔══██╗██╔════╝██╔══██╗
    //  ██║  ██║█████╗  ██║  ██║
    //  ██║  ██║██╔══╝  ██║  ██║
    //  ██████╔╝███████╗██████╔╝
    //  ╚═════╝ ╚══════╝╚═════╝ 
    /// <summary>
    /// An Action representing a DED motion.
    /// Relative Motion Disabled
    /// </summary>
    public class ActionDEDSolvedTransform : Action
    {
        public enum DEDMode
        {
            Start, 
            Mid,
            End
        }

        public Vector translation;
        public Rotation rotation;
        public int Cf1, Cf4, Cf6, Cfx;

        public DEDMode mode;
  
        public override ActionType Type => ActionType.DEDSolvedTransform;

        public ActionDEDSolvedTransform(double x, double y, double z, double vx0, double vx1, double vx2, double vy0,
            double vy1, double vy2, int cf1, int cf4, int cf6, int cfx, DEDMode mode) : base()
        {
            this.mode = mode;
            this.translation = new Vector(x, y, z);
            this.rotation = new Orientation(vx0, vx1, vx2, vy0, vy1, vy2);
            Cf1 = cf1;
            Cf4 = cf4;
            Cf6 = cf6;
            Cfx = cfx;
        }

        public ActionDEDSolvedTransform(Vector translation, Rotation rotation, int cf1, int cf4, int cf6, int cfx, DEDMode mode) : base()
        {
            this.mode = mode;
            this.translation = new Vector(translation);  // shallow copy
            this.rotation = new Rotation(rotation);  // shallow copy
            Cf1 = cf1;
            Cf4 = cf4;
            Cf6 = cf6;
            Cfx = cfx;
        }

        public override string ToString()
        {
            return string.Format("DED Solved Transform {0}: move to {1} mm, rotate to {2} with config [{3},{4},{5},{6}]", mode.ToString(), translation, new Orientation(rotation), Cf1, Cf4, Cf6, Cfx);
        }

        public override string ToInstruction()
        {
            Orientation ori = new Orientation(this.rotation);

            return string.Format("DEDSolvedTransformTo({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13});",
                    Math.Round(this.translation.X, Geometry.STRING_ROUND_DECIMALS_MM),
                    Math.Round(this.translation.Y, Geometry.STRING_ROUND_DECIMALS_MM),
                    Math.Round(this.translation.Z, Geometry.STRING_ROUND_DECIMALS_MM),
                    Math.Round(ori.XAxis.X, Geometry.STRING_ROUND_DECIMALS_MM),
                    Math.Round(ori.XAxis.Y, Geometry.STRING_ROUND_DECIMALS_MM),
                    Math.Round(ori.XAxis.Z, Geometry.STRING_ROUND_DECIMALS_MM),
                    Math.Round(ori.YAxis.X, Geometry.STRING_ROUND_DECIMALS_MM),
                    Math.Round(ori.YAxis.Y, Geometry.STRING_ROUND_DECIMALS_MM),
                    Math.Round(ori.YAxis.Z, Geometry.STRING_ROUND_DECIMALS_MM),
                    Cf1, Cf4, Cf6, Cfx,
                    (int)this.mode
                );
        }
    }
}
