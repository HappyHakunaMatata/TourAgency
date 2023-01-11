// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function CallAsyncRequest(callback, link) {
    $.ajax({
        type: "GET",
        url: link,
        dataType: "JSON",
        success: function (data) {
            callback(data);
        },
        error: function (status) {
            console.log(status);
        }
    });
}

function CallSyncRequest(url) {
    var result = $.ajax({
        type: "GET",
        dataType: "JSON",
        url: url,
        async: false
    }).success;
    return result;
}

function CreateRequest(country) {
    CallAsyncRequest(function (response) {
        isEmpty(response)
        AddOptions(response)
    }, "https://localhost:7268/Services/GetRegions?country=" + country);
}

function AddOptions(response) {
    $.each(response, function (i, obj) {
        $('#region').append('<option id="region-option">' + obj.name + '</option>');
    });
}

function isEmpty(response) {
    var count = Object.keys(response).length;
    if (count > 0) {
        $('#region').prop("disabled", false);
    }
    else {
        $('#region').prop("disabled", true);
    }
}

function hasChanged() {
    $("#country").change(function () {
        deleteOptions();
        var country = $("#country").find(":selected").text();
        CreateRequest(country);
    });
}

function deleteOptions() {
    $("#region-option").remove();
    console.log()
}

function onSignIn(googleUser) {
    var profile = googleUser.getBasicProfile();
    console.log('ID: ' + profile.getId()); // Do not send to your backend! Use an ID token instead.
    console.log('Name: ' + profile.getName());
    console.log('Image URL: ' + profile.getImageUrl());
    console.log('Email: ' + profile.getEmail()); //This is null if the 'email' scope is not present.
}

function signOut() {
    var auth2 = gapi.auth2.getAuthInstance();
    auth2.signOut().then(function () {
        console.log('User signed out.');
    });
}