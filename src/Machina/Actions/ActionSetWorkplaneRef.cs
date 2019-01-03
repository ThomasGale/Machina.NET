using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machina
{                                                                              
    /// <summary>
    /// Attaches a Tool to the robot flange. Must have beeb previously defined on the Robot.
    /// If the robot already had a tool, it will be replaced by this one.
    /// </summary>
    public class ActionSetWorkplaneRef : Action
    {
        public string workplaneName;

        public override ActionType Type => ActionType.SetWorkplaneRef;

        public ActionSetWorkplaneRef(string name) : base()
        {
            this.workplaneName = name;
        }

        public override string ToString()
        {
            return string.Format("Set workplane reference \"{0}\" for cartensian motions.", this.workplaneName);
        }

        public override string ToInstruction()
        {
            return $"SetWorkplaneRef(\"{this.workplaneName}\");";
        }
    }
}
