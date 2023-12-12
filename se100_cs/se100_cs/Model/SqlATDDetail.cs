﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace se100_cs.Model
{
    [Table("tb_attendance_detail")]
    public class SqlATDDetail
    {
        [Key]
        public long ID { get; set; }
        public TimeOnly time { get; set; } =new TimeOnly(1,1,1);
        public int status { get; set; } = 2;
        //0 la dung gio
        //1 la tre gio
        //2 la khong di lam
        public long employeeId { get; set; }
        public SqlAttendance attendance { get; set; }
    }
}
