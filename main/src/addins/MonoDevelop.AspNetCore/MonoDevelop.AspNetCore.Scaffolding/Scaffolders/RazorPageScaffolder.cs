﻿//
// Scaffolder.cs
//
// Author:
//       jasonimison <jaimison@microsoft.com>
//
// Copyright (c) 2019 Microsoft
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System.Collections.Generic;
using System.Linq;

namespace MonoDevelop.AspNetCore.Scaffolding
{
	class RazorPageScaffolder : RazorPageScaffolderBase
	{
		readonly ScaffolderArgs args;

		public RazorPageScaffolder (ScaffolderArgs args): base(args)
		{
			this.args = args;
		}

		public override IEnumerable<ScaffolderField> Fields => fields ?? GetFields();

		IEnumerable<ScaffolderField> GetFields()
		{
			var options = new List<BoolField> ();
			options.Add (PageModelField);
			options.Add (PartialViewField);
			options.Add (ReferenceScriptLibrariesField);
			options.Add (LayoutPageField);

			string [] viewTemplateOptions = new [] { "Empty", "Create", "Edit", "Delete", "Details", "List" };

			fields = new ScaffolderField [] {
				new StringField ("", "Name of the Razor Page"),
				new ComboField ("", "The template to use, supported view templates", viewTemplateOptions),
				GetDbContextField(args.Project),
				GetModelField(args.Project),
				new BoolFieldList(options),
				CustomLayoutField
			};

			return fields;
		}
	}
}
