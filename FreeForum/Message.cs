//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FreeForum
{
    using System;
    using System.Collections.Generic;
    
    public partial class Message
    {
        public Message()
        {
            this.Message1 = new HashSet<Message>();
            this.Subjects = new HashSet<Subject>();
        }
    
        public int Id { get; set; }
        public Nullable<int> ParentId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
        public System.DateTime PostDate { get; set; }
    
        public virtual ICollection<Message> Message1 { get; set; }
        public virtual Message Message2 { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
