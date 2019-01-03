using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machina
{
    //   █████╗ ████████╗████████╗ █████╗  ██████╗██╗  ██╗████████╗ ██████╗  ██████╗ ██╗     
    //  ██╔══██╗╚══██╔══╝╚══██╔══╝██╔══██╗██╔════╝██║  ██║╚══██╔══╝██╔═══██╗██╔═══██╗██║     
    //  ███████║   ██║      ██║   ███████║██║     ███████║   ██║   ██║   ██║██║   ██║██║     
    //  ██╔══██║   ██║      ██║   ██╔══██║██║     ██╔══██║   ██║   ██║   ██║██║   ██║██║     
    //  ██║  ██║   ██║      ██║   ██║  ██║╚██████╗██║  ██║   ██║   ╚██████╔╝╚██████╔╝███████╗
    //  ╚═╝  ╚═╝   ╚═╝      ╚═╝   ╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝   ╚═╝    ╚═════╝  ╚═════╝ ╚══════╝
    //                                                                                       
    /// <summary>
    /// Attaches a Tool to the robot flange. Must have beeb previously defined on the Robot.
    /// If the robot already had a tool, it will be replaced by this one.
    /// </summary>
    public class ActionSetToolRef : Action
    {
        public string toolName;

        public override ActionType Type => ActionType.SetToolRef;

        public ActionSetToolRef(string name) : base()
        {
            this.toolName = name;
        }

        public override string ToString()
        {
            return string.Format("Set tool reference \"{0}\" to robot flange.", this.toolName);
        }

        public override string ToInstruction()
        {
            return $"SetToolRef(\"{this.toolName}\");";
        }
    }
}
