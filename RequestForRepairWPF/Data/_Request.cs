using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Data
{
    public class _Request
    {
        //[Key]
        public int id_request { get; set; }
        public DateTime date_start { get; set; }
        public DateTime date_end { get; set; }
        public string status_request { get; set; }
        public int room_number { get; set; }
        public string name_request { get; set; }
        public string description_request { get; set; }
        public string comment_request { get; set; }
        public string inventory_number { get; set; }
        public string category_request { get; set; }
        public DateTime actual_date_end { get; set; }


        //public int userID_URC { get; set; }
        public List<Entities.Users> UsersC { get; set; }
        //public int userID_URE { get; set; }
        public List<Entities.Users> UsersE { get; set; }



        public _Request(Entities.Request request)
        {
            this.id_request = request.id_request;
            this.date_start = request.date_start;
            this.date_end = request.date_end;
            this.status_request = request.status_request;
            this.room_number = request.room_number;
            this.name_request = request.name_request;
            this.description_request = request.description_request;
            this.comment_request = request.comment_request;
            this.inventory_number = request.inventory_number;
            this.category_request = request.category_request;
            this.actual_date_end = (DateTime)request.actual_date_end;

            this.UsersC = request.Users.ToList();
            this.UsersE = request.Users1.ToList();
        }

        public _Request() { }
    }
}
