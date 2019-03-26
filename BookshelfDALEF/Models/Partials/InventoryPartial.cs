﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookshelfDALEF.Models
{
    public partial class Inventory
    {
        [NotMapped]
        public string AuthorBookName => $"{Author} + ({BookName})";

        public override string ToString()
        {
            //Поскольку автор или название могут быть не указаны, предоставить стандартные
            return $"{BookId}: {Author??"Без автора"} " +
                $"\"{BookName??"Без названия"}\", прочитано: {ReadStatus.ToString()}";
        }
    }
}