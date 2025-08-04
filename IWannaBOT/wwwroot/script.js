document.addEventListener("DOMContentLoaded", () => {
    const optionsSelect = document.getElementById("options");
    const status = document.getElementById("status");

    function loadOptions() {
        fetch("/api/options")
            .then(res => res.json())
            .then(data => {
                optionsSelect.innerHTML = "";
                data.forEach(opt => {
                    const option = document.createElement("option");
                    option.textContent = opt.text; // змінено з opt.name
                    option.value = opt.text;       // додано value
                    optionsSelect.appendChild(option);
                });
            })
            .catch(() => {
                optionsSelect.innerHTML = `<option>❌ Помилка завантаження</option>`;
            });
    }

    document.getElementById("send").addEventListener("click", () => {
        const selectedText = optionsSelect.value;
        fetch("/bot/send", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ text: selectedText }) // передаємо об'єкт
        })
            .then(res => {
                status.textContent = res.ok ? "✅ Надіслано" : "❌ Помилка";
            });
    });

    document.getElementById("add").addEventListener("click", () => {
        const input = document.getElementById("newOption");
        fetch("/api/options", {   // виправлено URL
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ text: input.value }) // поле "text" для бекенду
        })
            .then(() => {
                input.value = "";
                loadOptions();
            });
    });

    loadOptions();
});
