﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPrism72.CommonDialogs
{
	public interface ICommonDialogService
	{
		bool ShowDialog(IDialogSettings settings);
	}
}
