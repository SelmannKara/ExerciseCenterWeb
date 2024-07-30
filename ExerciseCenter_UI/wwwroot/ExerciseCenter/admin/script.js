document.addEventListener('DOMContentLoaded', () => {
    // Buraya yalnızca kullanıcı arayüzü efektleri ve etkileşimleri gelecek.
});

function showSection(sectionId) {
    document.querySelectorAll('.admin-section').forEach(section => {
        section.style.display = 'none';
    });
    document.getElementById(sectionId).style.display = 'block';
    document.getElementById('section-title').innerText = document.querySelector(`[onclick="showSection('${sectionId}')"]`).innerText;
}