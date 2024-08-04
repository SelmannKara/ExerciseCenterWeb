document.addEventListener('DOMContentLoaded', function () {
    var serviceDropdown = document.getElementById('service');
    var dateInput = document.getElementById('date');

    serviceDropdown.addEventListener('change', function () {
        var serviceId = this.value;
        fetch(`/api/appointments/available-dates/${serviceId}`)
            .then(response => response.json())
            .then(data => {
                // Flatpickr takvimini başlat ve mevcut tarihleri ayarla
                flatpickr(dateInput, {
                    enable: data.map(date => new Date(date)), // Tarihleri kullanıma aç
                    dateFormat: "Y-m-d", // Tarih formatı
                    minDate: "today", // Bugünden önceki tarihleri devre dışı bırak
                });
            });
    });

    // İlk sayfa yüklendiğinde de takvimi başlat
    flatpickr(dateInput, {
        dateFormat: "Y-m-d",
        minDate: "today",
    });
});
