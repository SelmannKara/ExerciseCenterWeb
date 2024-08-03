function showSection(sectionId) {
    const sections = document.querySelectorAll('.admin-section');
    sections.forEach(section => section.style.display = 'none');

    const selectedSection = document.getElementById(sectionId);
    if (selectedSection) {
        selectedSection.style.display = 'block';
        document.getElementById('section-title').innerText = selectedSection.querySelector('h3').innerText;
    }
}

document.getElementById('menu-toggle').addEventListener('click', function() {
    document.getElementById('wrapper').classList.toggle('toggled');
});
