﻿using System;
using System.ComponentModel.DataAnnotations;

namespace WaiterPhoneApp.Models
{
    public abstract class BaseModel : IEquatable<BaseModel>
    {
        [Key]
        public int Id { get; set; }

        public abstract bool Equals(BaseModel other);
    }
}
