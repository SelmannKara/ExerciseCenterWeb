$(document).ready(function () {
    console.log("Script çalıştırıldı");

    // jQuery UI Datepicker'ı başlatıyoruz
    $("#datepicker").datepicker({
        dateFormat: "yy-mm-dd",
        beforeShowDay: function (date) {
            var string = jQuery.datepicker.formatDate('yy-mm-dd', date);
            return [disabledDates.indexOf(string) == -1];
        }
    });

    // Saat seçeneklerini yarım saat aralıklarla ekliyoruz
    var startTime = 9; // 9:00 AM
    var endTime = 18; // 6:00 PM
    var timeInterval = 30; // Dakika olarak aralık (yarım saat)

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
