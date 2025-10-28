# Avae.Printables.Xps

A crossplatform library for printing.

# Features

Cross-Platform : Leverage APIs adapted for multiple environments.

MIT Licensed: Freely use, modify, and distribute under the permissive MIT License.

# Getting Started

Follow these steps to integrate Avae.Printables into your Avalonia project.

# Prerequisites

An Avalonia project set up with .NET.

# Installation

Add Nuget Avae.Printables.Xps to Your Windows Project

# Configuration

Enable Printables on windows only.

````
 using Avae.Printables;
 public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePrintables()
            .UseXpsPrintables()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
````

# Example: Print

````
using Avae.Printable;

Printables.PrintAsync("C://Temp//test.xps");

````

# Built With

This package builds upon the excellent work of:

AvaloniaUI

XpsToPdf

# License

Avae.Printables.Xps is licensed under the MIT License.

# Contributing

Contributions are welcome! Please submit issues or pull requests to the GitHub repository. Ensure your code follows the project’s coding standards.