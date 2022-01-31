// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.



// Jquery object for the datepicker - locked to current date and 5 days ahead. Using MaxLength=0 on the front HTML to prevent any user interaction while still allowing for the online post
$(function () {
    $("#datepicker").datepicker({ minDate: 0, maxDate: "+5D" });
});

// get city name and description and fetch forecast then update page
function GetWeatherNow(cityName,CityLabel) {
    const key = "mykey";
    let formDay = document.getElementById("datepicker").value.toString();
    let PickedDay = moment(formDay, "MM-DD-YYYY");
    var CurrentDay = moment(new Date());
    var TimeDifferenceInHours = PickedDay.diff(CurrentDay, 'hours');



    // Openweathermap delivers forecasts in 3 hour seperations, so by calculating the number of hours till the date in the future and /3 we can find what json object index we need to display

    if (document.getElementById("datepicker").value !== null) {

        var day = Math.trunc(TimeDifferenceInHours/3)
        console.log(day);

    } else {
        day = 0;
        
    }
    fetch('https://api.openweathermap.org/data/2.5/forecast?q=' + cityName + '&appid=' + key + '&units=metric')
        .then(function (resp) { return resp.json() }) // Convert data to json
        .then(function (data) {
            console.log(data);
            document.getElementById("WeatherInfoText").innerHTML = data.list[day].weather[0].main + ',' + data.list[day].main.temp + 'C';
            document.getElementById("CityDesc").innerHTML = CityLabel.replace(/_/g, ' ');
        })
        .catch(function () {
            // catch any errors
        });
}
