//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Logbook_System.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student_Eval
    {
        public string ID { get; set; }
        public string MentorID { get; set; }
        public string StudentID { get; set; }
        public string WorkplaceExperience { get; set; }
        public string LearningProcess { get; set; }
        public string CommunicationSkills { get; set; }
        public string AccomodationOfLearners { get; set; }
        public string LearnerProblemSolving { get; set; }
        public string FinalJudgement { get; set; }
        public string Comments { get; set; }
        public string LeanerSign { get; set; }
        public string MentorSign { get; set; }
    
        public virtual Mentor Mentor { get; set; }
        public virtual Student Student { get; set; }
    }
}