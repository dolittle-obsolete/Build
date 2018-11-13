/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
#load "common.cake"
Task("Default")
    .IsDependentOn("Common");

Information($"Run target : '{target}'");
RunTarget(target);