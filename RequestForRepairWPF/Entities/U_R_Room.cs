//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RequestForRepairWPF.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class U_R_Room
    {
        public int userID_URR { get; set; }
        public Nullable<int> id_type_room_URR { get; set; }
        public int id_room { get; set; }
    
        public virtual Rooms Rooms { get; set; }
        public virtual TypeRoom TypeRoom { get; set; }
        public virtual User User { get; set; }
    }
}
