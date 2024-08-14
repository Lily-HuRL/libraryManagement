﻿using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libraryManagement.Utils
{
    public class MessageHelper
    {
        private readonly IJSRuntime _jsRuntime;

        public MessageHelper(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task ShowMessage(string str)
        {
            await _jsRuntime.InvokeVoidAsync("alert", str);
        }
    }
}
