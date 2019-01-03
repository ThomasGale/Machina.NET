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
    public class ActionDED : Action
    {
        public enum DEDMode
        {
            Start, 
            Mid,
            End
        }

        public Vector translation;
        public Rotation rotation;
        public DEDMode mode;
  
        public override ActionType Type => ActionType.DED;

        public ActionDED(DEDMode mode, double x, double y, double z, double vx0, double vx1, double vx2, double vy0,
            double vy1, double vy2) : base()
        {
            this.mode = mode;
            this.translation = new Vector(x, y, z);
            this.rotation = new Orientation(vx0, vx1, vx2, vy0, vy1, vy2);
        }

        public ActionDED(DEDMode mode, Vector translation, Rotation rotation) : base()
        {
            this.mode = mode;
            this.translation = new Vector(translation);  // shallow copy
            this.rotation = new Rotation(rotation);  // shallow copy
        }

        public override string ToString()
        {
            return string.Format("DED {0}: move to {1} mm, rotate to {2}", mode.ToString(), translation, new Orientation(rotation));
        }

        public override string ToInstruction()
        {
            Orientation ori = new Orientation(this.rotation);

            return string.Format("DEDTo({0},{1},{2},{3},{4},{5},{6},{7},{8},{9});",
                    Math.Round(this.translation.X, Geometry.STRING_ROUND_DECIMALS_MM),
                    Math.Round(this.translation.Y, Geometry.STRING_ROUND_DECIMALS_MM),
                    Math.Round(this.translation.Z, Geometry.STRING_ROUND_DECIMALS_MM),
                    Math.Round(ori.XAxis.X, Geometry.STRING_ROUND_DECIMALS_MM),
                    Math.Round(ori.XAxis.Y, Geometry.STRING_ROUND_DECIMALS_MM),
                    Math.Round(ori.XAxis.Z, Geometry.STRING_ROUND_DECIMALS_MM),
                    Math.Round(ori.YAxis.X, Geometry.STRING_ROUND_DECIMALS_MM),
                    Math.Round(ori.YAxis.Y, Geometry.STRING_ROUND_DECIMALS_MM),
                    Math.Round(ori.YAxis.Z, Geometry.STRING_ROUND_DECIMALS_MM),
                    this.mode.ToString()
                );
        }
    }
}
