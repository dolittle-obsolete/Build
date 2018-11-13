/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
#addin nuget:?package=Cake.Git&version=0.19.0
#load "globals.cake"
using System.Net.Http;

var target = Argument("target", "Default");

Task("CloneAndCheckout")
    .Does(() =>
    {
        GitClone(globals.repository, globals.source_path, new GitCloneSettings
        {
            RecurseSubmodules = true
        });
        if (!string.IsNullOrEmpty(globals.commit))
        {
            Information($"Checking out to {globals.commit}");
            GitCheckout(globals.source_path, globals.commit);
        }
    });

Task("Checkout")
    .Does(() =>
    {
        if (!string.IsNullOrEmpty(globals.commit))
        {
            Information($"Checking out to {globals.commit}");
            GitCheckout(globals.source_path, globals.commit);
        }
    });


Task("Globals")
    .Does(globals.Initialize);

Task("Common")
    .IsDependentOn("Globals")
    .IsDependentOn("Checkout")
    .Does(() =>
    {
        Information($"Version is {globals.version}");
    });

Teardown(context => 
{
    var callbackUrl = globals.callbackUrl;
    if( !string.IsNullOrEmpty(callbackUrl)) 
    {
        var client = new HttpClient();
        var content = new FormUrlEncodedContent(new Dictionary<string,string>());
        client.PostAsync(callbackUrl, content).Wait();
    }
});