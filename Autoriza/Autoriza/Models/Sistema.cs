using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autoriza.Models.Validation;
using FluentValidation.Attributes;

namespace Autoriza.Models
{

    [Validator(typeof(SistemaValidation))]
    public class Sistema
    {

        public virtual int Id { get; set; }

        public virtual String Nome { get; set; }

        public virtual String Url { get; set; }

    }
}