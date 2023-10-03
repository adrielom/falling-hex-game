using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Godot;

namespace Scripts.Configs
{

    public enum UI_CANCEL_STATE
    {
        ENTER, EXIT
    }
    public class MainConfigs
    {
        private UI_CANCEL_STATE uiCancelState = UI_CANCEL_STATE.ENTER;
        public MainConfigs()
        {
            Input.MouseMode = Input.MouseModeEnum.Captured;
        }


        public void ChangeMouseModeOnKeyPressed(InputEvent inputEvent)
        {
            if (inputEvent.IsActionPressed("ui_cancel"))
            {
                if (uiCancelState == UI_CANCEL_STATE.ENTER)
                {
                    uiCancelState = UI_CANCEL_STATE.EXIT;
                    Input.MouseMode = Input.MouseModeEnum.Visible;
                    return;
                }
                uiCancelState = UI_CANCEL_STATE.ENTER;
                Input.MouseMode = Input.MouseModeEnum.Captured;

            }
        }
    }
}