using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace BlazorTyper
{
    public class TyperBase : ComponentBase
    {
        [Parameter] public bool Start { get; set; }
        [Parameter] public string Text { get; set; }
        [Parameter] public int Repeat { get; set; }
        [Parameter] public bool EraseBeforeRepeat { get; set; }
        [Parameter] public TimeSpan? TypingDelay { get; set; }
        [Parameter] public TimeSpan PreTypingDelay { get; set; } = TimeSpan.Zero;

        protected string TypingText { get; set; }
        protected int RepeatCount { get; set; }
        protected TimeSpan TypingDelayOrRandom => TypingDelay ?? TimeSpan.FromMilliseconds(new Random().Next(20, 100));

        protected override async Task OnParametersSetAsync()
        {
            if (Start)
            {
                await Task.Delay(PreTypingDelay);
                await StartTypingAsync();

                while (RepeatCount < Repeat)
                {
                    if (EraseBeforeRepeat)
                    {
                        await StartErasingAsync();
                    }

                    await Task.Delay(PreTypingDelay);
                    await StartTypingAsync();
                    RepeatCount++;
                }
            }
        }

        private async Task StartTypingAsync()
        {
            TypingText = string.Empty;

            foreach (var c in Text)
            {
                TypingText += c;
                StateHasChanged();

                await Task.Delay(TypingDelayOrRandom);
            }
        }

        private async Task StartErasingAsync()
        {
            while (TypingText.Length > 0)
            {
                TypingText = TypingText.Remove(TypingText.Length - 1);
                StateHasChanged();

                await Task.Delay(TypingDelayOrRandom);
            }
        }
    }
}
