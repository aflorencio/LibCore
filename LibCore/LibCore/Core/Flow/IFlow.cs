using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibCore
{
    public interface IFlow
    {
        void CreateFlow();
        void CreateTimelineFlow();
        void UpdateFlow();
        void ReadAllFlow();
        void ReadOneFlow();
        /// <summary>
        /// No lo eliminara pondrá un campo como invisible
        /// </summary>
        void DeleteFlow();
    }
}