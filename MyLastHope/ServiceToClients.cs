//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyLastHope
{
    using System;
    using System.Collections.Generic;
    
    public partial class ServiceToClients
    {
        public int ID_serviceclient { get; set; }
        public int ID_service { get; set; }
        public Nullable<System.DateTime> BeginningDate { get; set; }
        public int ID_client { get; set; }
    
        public virtual Clients Clients { get; set; }
        public virtual Services Services { get; set; }
    }
}
