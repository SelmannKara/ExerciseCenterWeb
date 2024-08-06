$(function () {
    // Disable specific dates
    $("#datepicker").datepicker({
        dateFormat: "yy-mm-dd",
        beforeShowDay: function (date) {
            var string = jQuery.datepicker.formatDate('yy-mm-dd', date);
            return [disabledDates.indexOf(string) == -1];
        }
    });

    // Time selection with 30-minute intervals
    var startTime = 9; // 9:00 AM
    var endTime = 18; // 6:00 PM
    var timeInterval = 30; // 30-minute intervals

    var timeSelect = $("#time");

    for (var hour = startTime; hour < endTime; hour++) {
        var minutes = 0;
        while (minutes < 60) {
            var timeValue = (hour < 10 ? "0" : "") + hour + ":" + (minutes < 10 ? "0" : "") + minutes;
            timeSelect.append(new Option(timeValue, timeValue));
            minutes += timeInterval;
        }
    }
});
