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
    /// An Action representing setting DED Parameters.
    /// </summary>
    public class ActionDEDParmaters : Action
    {
        public readonly int synergicLine = 72;
        public readonly int weldingMode = 7;
        public readonly int arcLengthCorrection = 1;
        public readonly int dyanamicEPENCorrection = 5;

        // mm/s
        public double travelSpeed = 8.0;
        // *** units need checking
        public double materialFlow = 11.0;


        public override ActionType Type => ActionType.DEDParameter;

        public ActionDEDParmaters(double travelSpeed, double materialFlow) : base()
        {
            this.travelSpeed = travelSpeed;
            this.materialFlow = materialFlow;
        }

        public override string ToString()
        {
            return string.Format("Set DED Parameters to: travelSpeed {0} and materialFlow {1}", travelSpeed, materialFlow);
        }

        public override string ToInstruction() => null;
    }
}
