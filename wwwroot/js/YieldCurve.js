window.renderYieldCurve = (labels, data, title) => {

    if (typeof Chart === "undefined") {
        console.error("Chart.js is not loaded!");
        return;
    }

    const ctx = document.getElementById('yieldCurveChart').getContext('2d');

    if (window.yieldChart) {
        window.yieldChart.destroy();
    }

    window.yieldChart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: labels,
            datasets: [{
                label: title,
                data: data,
                borderColor: 'rgb(75, 192, 192)',
                tension: 0.2,
                fill: false
            }]
        },
        options: {
            responsive: true,
            scales: {
                y: { title: { display: true, text: 'Balance Growth ($)' } },
                x: { title: { display: true, text: 'Term' } }
            }
        }
    });
};
