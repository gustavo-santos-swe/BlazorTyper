# BlazorTyper
Blazor component to simulate text being typed.

![BlazorTyperGif](https://media.giphy.com/media/S936kVpcDGKmc7rGvy/giphy.gif)

### Prerequisites:
- Blazor WebAssembly
- Microsoft.AspNetCore.Blazor [minimum version: 3.2.0-preview1]

### How to install:

Run the following command in your terminal, inside the project folder (or, install via Nuget, the package BlazorTyper):<br/>
`dotnet add package BlazorTyper`

In your _Imports.razor file or in the component file, include: <br/>
`@using BlazorTyper`

### Basic usage:
Call the component:
```html
<Typer Text="Hello world from BlazorTyper" Start="true" />
``` 

### Parameters:

|Parameter|Type|Description|Default Value|
|---------|----|-----------|-------------|
|Text|string|Text that will be typed|null|
|Start|bool|Should start the typing|false|
|Repeat|int|Times to repeat the typing after the first iteration|0|
|EraseBeforeRepeat|bool|Should simulate the text erasure before the next iteration|false|
|PreTypingDelay|TimeSpan|Delay time before the typing|TimeSpan.Zero|
|TypingDelay|TimeSpan|Delay time between every text character|Random beetween 20 and 100 milliseconds|

### Having issues?
- Create a new Issue in this repository with more informations, or, create your own pull request. :) 
