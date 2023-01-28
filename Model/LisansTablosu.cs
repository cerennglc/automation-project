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
    
    public partial class LisansTablosu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LisansTablosu()
        {
            this.BasvuruTablosu = new HashSet<BasvuruTablosu>();
            this.BasvuruTablosu1 = new HashSet<BasvuruTablosu>();
        }
    
        public int ID { get; set; }
        public int Fk_KisiID { get; set; }
        public int Fk_UniversiteID { get; set; }
        public int Fk_FakulteID { get; set; }
        public int Fk_BolumID { get; set; }
        public Nullable<decimal> DiplomaNotu { get; set; }
        public Nullable<bool> NotSistemi { get; set; }
        public string DiplomaOrnegi { get; set; }
        public int Fk_EgitimTuruID { get; set; }
        public Nullable<System.DateTime> KayitTarihi { get; set; }
        public string IpAdresi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BasvuruTablosu> BasvuruTablosu { get; set; }
        public virtual BolumTablosu BolumTablosu { get; set; }
        public virtual EgitimTuru EgitimTuru { get; set; }
        public virtual FakulteTablosu FakulteTablosu { get; set; }
        public virtual KisiTablosu KisiTablosu { get; set; }
        public virtual UniversiteTablosu UniversiteTablosu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BasvuruTablosu> BasvuruTablosu1 { get; set; }
    }
}