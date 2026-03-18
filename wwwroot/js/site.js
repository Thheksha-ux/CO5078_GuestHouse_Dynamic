document.addEventListener("DOMContentLoaded", function () {

    // Hero Slider
    let slides = document.querySelectorAll(".slide");
    let currentSlide = 0;

    function showSlide(index) {
        slides.forEach((slide, i) => {
            slide.classList.remove("active");
            if (i === index) {
                slide.classList.add("active");
            }
        });
    }

    if (slides.length > 0) {
        showSlide(currentSlide);

        setInterval(function () {
            currentSlide = (currentSlide + 1) % slides.length;
            showSlide(currentSlide);
        }, 3000);
    }

    // Testimonial Slider
    let testimonials = document.querySelectorAll(".testimonial");
    let currentTestimonial = 0;

    function showTestimonial(index) {
        testimonials.forEach((item, i) => {
            item.classList.remove("active");
            if (i === index) {
                item.classList.add("active");
            }
        });
    }

    if (testimonials.length > 0) {
        showTestimonial(currentTestimonial);

        setInterval(function () {
            currentTestimonial = (currentTestimonial + 1) % testimonials.length;
            showTestimonial(currentTestimonial);
        }, 4000);
    }
});