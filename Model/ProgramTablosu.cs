//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YukseklisansProje.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProgramTablosu
    {
        public int ID { get; set; }
        public string ProgramAd { get; set; }
        public int Fk_FakulteID { get; set; }
        public int Fk_BolumID { get; set; }
        public int Kontenjan { get; set; }
        public bool TezDurumu { get; set; }
        public string Detay { get; set; }
        public string PrograminDili { get; set; }
        public bool YuksekLisansMi { get; set; }
    
        public virtual BolumTablosu BolumTablosu { get; set; }
        public virtual FakulteTablosu FakulteTablosu { get; set; }
    }
}
