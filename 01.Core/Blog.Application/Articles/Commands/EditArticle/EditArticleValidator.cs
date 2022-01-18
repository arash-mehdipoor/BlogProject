﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Articles.Commands.EditArticle
{
    public class EditArticleValidator : AbstractValidator<EditArticleCommand>
    {
        public EditArticleValidator()
        {
            RuleFor(u => u.Title).Length(2, 150).NotEmpty().WithMessage("Can Not Be Null");
            RuleFor(u => u.Body).NotEmpty().WithMessage("Can Not Be Null");
        }
    }
}
