// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

'use strict';

$(function () {

    $("#btnGetTime").click(function () {
        $.ajax({
            url: "/Index?handler=Time",
            success: GetTimeSucceeded,
            error: AjaxFailed,
            cache: false
        });
    });

    $('#btnGetRandomUser').click(function () {
        $.ajax({
            url: 'https://randomuser.me/api/',
            dataType: 'json',
            success: gotUser,
            error: AjaxFailed
        });
    });

    $('#btnPostNoData').click(function () {
        $.ajax({
            type: "POST",
            url: "/Index?handler=Send",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("XSRF-TOKEN",
                    $('input:hidden[name="__RequestVerificationToken"]').val());
            },        
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: getListItems,
            error: AjaxFailed
        });
    });

    $('#btnPostPerson').click(function () {
        var fname = $('#txtfirstname').val();
        var lname = $('#txtlastname').val();
        $.ajax({
            type: "POST",
            url: "/Index?handler=SendPerson",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("XSRF-TOKEN",
                    $('input:hidden[name="__RequestVerificationToken"]').val());
            },
            data: JSON.stringify({
                FirstName: fname,
                LastName: lname
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: displayName,
            error: AjaxFailed
        });
    });
});

function displayName(response) {
    var ans = "Person in upper case is:  <strong>" + response.firstName + " " + response.lastName + "</strong>";
    $("#dvPostName").html(ans);
}

function getListItems(response) {
    $("#dvPostItems").html(response);
}

function gotUser(user) {
    var thisUser = user.results[0];

    $('#randomUser').html(
        '<img id=userPicture src=' + thisUser.picture.large +
        ' /><br /> <br />' +
        thisUser.name.title + ' ' +
        thisUser.name.first + ' ' +
        thisUser.name.last + '<br />' +
        thisUser.location.street + '<br />' +
        thisUser.location.city + '<br />' +
        thisUser.nat + '<br />' +
        thisUser.email + '<br />' +
        'Username: ' +
        thisUser.login.username + '<br /><br />'
    )
        .css({
            'background-color': 'lightblue',
            'color': 'red',
            'font-size': 'large'
        });
}


function GetTimeSucceeded(response) {
    $("#lblTime").html(response).css({ "background-color": "yellow", "color": "blue", "fontsize": "larger" });
}


function AjaxFailed(response) {
    alert(response.status + ' ' + response.statusText);
}


