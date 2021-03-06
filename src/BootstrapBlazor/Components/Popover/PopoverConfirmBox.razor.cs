﻿using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace BootstrapBlazor.Components
{
    /// <summary>
    /// Popover Confirm 组件
    /// </summary>
    public partial class PopoverConfirmBox
    {
        /// <summary>
        /// 获得 组件样式
        /// </summary>
        protected string? ClassName => CssBuilder.Default("popover fade")
            .AddClassFromAttributes(AdditionalAttributes)
            .Build();

        /// <summary>
        /// 获得 关闭按钮样式
        /// </summary>
        protected string? CloseButtonClass => CssBuilder.Default("btn btn-xs")
            .AddClass($"btn-{CloseButtonColor.ToDescriptionString()}")
            .Build();

        /// <summary>
        /// 获得 关闭按钮样式
        /// </summary>
        protected string? ConfirmButtonClass => CssBuilder.Default("btn btn-xs")
            .AddClass($"btn-{ConfirmButtonColor.ToDescriptionString()}")
            .Build();

        /// <summary>
        /// 获得 图标样式
        /// </summary>
        protected string? IconClass => CssBuilder.Default("fa")
            .AddClass(Icon)
            .Build();

        /// <summary>
        /// 获得/设置 关联按钮 Id
        /// </summary>
        [Parameter] public string? SourceId { get; set; }

        /// <summary>
        /// 获得/设置 显示标题
        /// </summary>
        [Parameter] public string? Title { get; set; }

        /// <summary>
        /// 获得/设置 显示文字
        /// </summary>
        [Parameter] public string Content { get; set; } = "Popover Confirm";

        /// <summary>
        /// 获得/设置 关闭按钮显示文字
        /// </summary>
        [Parameter] public string CloseButtonText { get; set; } = "关闭";

        /// <summary>
        /// 获得/设置 确认按钮颜色
        /// </summary>
        [Parameter] public Color CloseButtonColor { get; set; } = Color.Secondary;

        /// <summary>
        /// 获得/设置 确认按钮显示文字
        /// </summary>
        [Parameter] public string ConfirmButtonText { get; set; } = "确定";

        /// <summary>
        /// 获得/设置 确认按钮颜色
        /// </summary>
        [Parameter] public Color ConfirmButtonColor { get; set; } = Color.Primary;

        /// <summary>
        /// 获得/设置 确认框图标
        /// </summary>
        [Parameter] public string? Icon { get; set; } = "fa-exclamation-circle text-info";

        /// <summary>
        /// 获得/设置 确认按钮回调方法
        /// </summary>
        [Parameter] public Func<Task>? OnConfirm { get; set; }

        /// <summary>
        /// 获得/设置 确认按钮回调方法
        /// </summary>
        [Parameter] public Func<Task> OnClose { get; set; } = () => Task.CompletedTask;

        /// <summary>
        /// 获得/设置 PopoverConfirm 服务实例
        /// </summary>
        [Inject] private PopoverService? PopoverService { get; set; }

        /// <summary>
        /// 点击关闭按钮调用此方法
        /// </summary>
        public async Task OnCloseClick()
        {
            PopoverService?.Hide();
            await OnClose.Invoke();
        }

        /// <summary>
        /// 点击确认按钮调用此方法
        /// </summary>
        public async Task OnConfirmClick()
        {
            PopoverService?.Hide();
            if (OnConfirm != null) await OnConfirm();
        }
    }
}
