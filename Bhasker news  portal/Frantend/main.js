// Mobile Navigation Toggle
const hamburger = document.getElementById('hamburger');
const nav = document.querySelector('.nav');

if (hamburger && nav) {
    hamburger.addEventListener('click', () => {
        hamburger.classList.toggle('active');
        nav.classList.toggle('active');
    });
}

// Close mobile menu when clicking on nav links
const navLinks = document.querySelectorAll('.nav-link');
navLinks.forEach(link => {
    link.addEventListener('click', () => {
        if (hamburger && nav) {
            hamburger.classList.remove('active');
            nav.classList.remove('active');
        }
    });
});

// Hero Slider Functionality
const slides = document.querySelectorAll('.slide');
const dots = document.querySelectorAll('.dot');
const prevBtn = document.getElementById('prevBtn');
const nextBtn = document.getElementById('nextBtn');

let currentSlide = 0;

function showSlide(index) {
    // Remove active class from all slides and dots
    slides.forEach(slide => slide.classList.remove('active'));
    dots.forEach(dot => dot.classList.remove('active'));
    
    // Add active class to current slide and dot
    if (slides[index]) {
        slides[index].classList.add('active');
    }
    if (dots[index]) {
        dots[index].classList.add('active');
    }
}

function nextSlide() {
    currentSlide = (currentSlide + 1) % slides.length;
    showSlide(currentSlide);
}

function prevSlide() {
    currentSlide = (currentSlide - 1 + slides.length) % slides.length;
    showSlide(currentSlide);
}

// Event listeners for slider controls
if (nextBtn) {
    nextBtn.addEventListener('click', nextSlide);
}

if (prevBtn) {
    prevBtn.addEventListener('click', prevSlide);
}

// Dot navigation
dots.forEach((dot, index) => {
    dot.addEventListener('click', () => {
        currentSlide = index;
        showSlide(currentSlide);
    });
});

// Auto-play slider
if (slides.length > 0) {
    setInterval(nextSlide, 5000); // Change slide every 5 seconds
}

// Newsletter Form Submission
const newsletterForms = document.querySelectorAll('.newsletter-form');

newsletterForms.forEach(form => {
    form.addEventListener('submit', (e) => {
        e.preventDefault();
        
        const newsletterInput = form.querySelector('.newsletter-input');
        const newsletterBtn = form.querySelector('.newsletter-btn');
        const email = newsletterInput.value.trim();
        
        if (email && isValidEmail(email)) {
            // Simulate subscription process
            newsletterBtn.textContent = 'सदस्यता ली जा रही है...';
            newsletterBtn.disabled = true;
            
            setTimeout(() => {
                newsletterBtn.textContent = 'सदस्यता ली गई!';
                newsletterInput.value = '';
                
                setTimeout(() => {
                    newsletterBtn.textContent = 'सदस्यता लें';
                    newsletterBtn.disabled = false;
                }, 2000);
            }, 2000);
        } else {
            alert('कृपया एक वैध ईमेल पता दर्ज करें');
        }
    });
});

// Email validation function
function isValidEmail(email) {
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailRegex.test(email);
}

// Contact Form Submission
const contactForm = document.getElementById('contactForm');
if (contactForm) {
    contactForm.addEventListener('submit', (e) => {
        e.preventDefault();
        
        const formData = new FormData(contactForm);
        const submitBtn = contactForm.querySelector('.submit-btn');
        
        // Simulate form submission
        submitBtn.textContent = 'भेजा जा रहा है...';
        submitBtn.disabled = true;
        
        setTimeout(() => {
            alert('आपका संदेश सफलतापूर्वक भेज दिया गया है। हम जल्द ही आपसे संपर्क करेंगे।');
            contactForm.reset();
            submitBtn.textContent = 'संदेश भेजें';
            submitBtn.disabled = false;
        }, 2000);
    });
}

// FAQ Toggle Functionality
const faqItems = document.querySelectorAll('.faq-item');
faqItems.forEach(item => {
    const question = item.querySelector('.faq-question');
    question.addEventListener('click', () => {
        const isActive = item.classList.contains('active');
        
        // Close all FAQ items
        faqItems.forEach(faqItem => {
            faqItem.classList.remove('active');
        });
        
        // Open clicked item if it wasn't active
        if (!isActive) {
            item.classList.add('active');
        }
    });
});

// Read More Button Functionality
const readMoreBtns = document.querySelectorAll('.read-more-btn');
readMoreBtns.forEach(btn => {
    btn.addEventListener('click', (e) => {
        // Only prevent default if it's a button, not a link
        if (btn.tagName === 'BUTTON') {
            e.preventDefault();
            
            // Simulate article loading
            const originalText = btn.textContent;
            btn.textContent = 'लोड हो रहा है...';
            btn.disabled = true;
            
            setTimeout(() => {
                alert('वास्तविक implementation में यहाँ लेख खुलेगा');
                btn.textContent = originalText;
                btn.disabled = false;
            }, 500);
        }
    });
});

// Smooth scrolling for anchor links
document.querySelectorAll('a[href^="#"]').forEach(anchor => {
    anchor.addEventListener('click', function (e) {
        e.preventDefault();
        const target = document.querySelector(this.getAttribute('href'));
        if (target) {
            target.scrollIntoView({
                behavior: 'smooth',
                block: 'start'
            });
        }
    });
});

// Search functionality (basic implementation)
const searchBtn = document.querySelector('.search-btn');
const searchInput = document.querySelector('.search-input');

if (searchBtn) {
    searchBtn.addEventListener('click', () => {
        const searchQuery = searchInput ? searchInput.value.trim() : prompt('अपनी खोज दर्ज करें:');
        if (searchQuery && searchQuery.trim()) {
            alert(`खोज रहे हैं: "${searchQuery}"\n\nवास्तविक implementation में यह खोज परिणामों पर redirect करेगा।`);
        }
    });
}

if (searchInput) {
    searchInput.addEventListener('keypress', (e) => {
        if (e.key === 'Enter') {
            const searchQuery = searchInput.value.trim();
            if (searchQuery) {
                alert(`खोज रहे हैं: "${searchQuery}"\n\nवास्तविक implementation में यह खोज परिणामों पर redirect करेगा।`);
            }
        }
    });
}

// Add loading animation for images
const images = document.querySelectorAll('img');
images.forEach(img => {
    img.addEventListener('load', () => {
        img.style.opacity = '1';
    });
    
    img.addEventListener('error', () => {
        img.style.opacity = '0.5';
        img.alt = 'चित्र लोड नहीं हो सका';
    });
});

// Intersection Observer for fade-in animations
const observerOptions = {
    threshold: 0.1,
    rootMargin: '0px 0px -50px 0px'
};

const observer = new IntersectionObserver((entries) => {
    entries.forEach(entry => {
        if (entry.isIntersecting) {
            entry.target.style.opacity = '1';
            entry.target.style.transform = 'translateY(0)';
        }
    });
}, observerOptions);

// Observe news cards for animation
const newsCards = document.querySelectorAll('.news-card');
newsCards.forEach(card => {
    card.style.opacity = '0';
    card.style.transform = 'translateY(20px)';
    card.style.transition = 'opacity 0.6s ease, transform 0.6s ease';
    observer.observe(card);
});

// Add click tracking for analytics (placeholder)
document.addEventListener('click', (e) => {
    const target = e.target;
    
    // Track news card clicks
    if (target.closest('.news-card')) {
        const newsTitle = target.closest('.news-card').querySelector('.news-title');
        if (newsTitle) {
            console.log('News card clicked:', newsTitle.textContent);
        }
    }
    
    // Track navigation clicks
    if (target.classList.contains('nav-link')) {
        console.log('Navigation clicked:', target.textContent);
    }
    
    // Track social media clicks
    if (target.closest('.social-link')) {
        console.log('Social media clicked:', target.closest('.social-link').getAttribute('aria-label'));
    }
});

// Handle window resize for responsive adjustments
let resizeTimer;
window.addEventListener('resize', () => {
    clearTimeout(resizeTimer);
    resizeTimer = setTimeout(() => {
        // Close mobile menu on resize to desktop
        if (window.innerWidth > 768) {
            if (hamburger && nav) {
                hamburger.classList.remove('active');
                nav.classList.remove('active');
            }
        }
    }, 250);
});

// Add keyboard navigation support
document.addEventListener('keydown', (e) => {
    // ESC key closes mobile menu
    if (e.key === 'Escape') {
        if (hamburger && nav) {
            hamburger.classList.remove('active');
            nav.classList.remove('active');
        }
    }
    
    // Enter key on search button
    if (e.key === 'Enter' && e.target === searchBtn) {
        searchBtn.click();
    }
    
    // Arrow keys for slider navigation
    if (slides.length > 0) {
        if (e.key === 'ArrowLeft') {
            prevSlide();
        } else if (e.key === 'ArrowRight') {
            nextSlide();
        }
    }
});

// Initialize page
document.addEventListener('DOMContentLoaded', () => {
    console.log('भास्कर न्यूज़ पोर्टल सफलतापूर्वक लोड हुआ');
    
    // Add smooth fade-in for hero section
    const hero = document.querySelector('.hero') || document.querySelector('.hero-slider');
    if (hero) {
        hero.style.opacity = '0';
        hero.style.transform = 'translateY(30px)';
        hero.style.transition = 'opacity 1s ease, transform 1s ease';
        
        setTimeout(() => {
            hero.style.opacity = '1';
            hero.style.transform = 'translateY(0)';
        }, 300);
    }
    
    // Initialize first slide as active if slider exists
    if (slides.length > 0) {
        showSlide(0);
    }
});


window.onload = function () {
    // Example check for login status (set true manually for test)
    // localStorage.setItem("isLoggedIn", "true");
    if (localStorage.getItem("isLoggedIn") === "true") {
      document.getElementById("fullNews").style.display = "block";
      document.getElementById("loginPrompt").style.display = "none";
    }
  };

//   ==================================================

  // Hamburger Menu Toggle
  document.getElementById("hamburger").addEventListener("click", function () {
    document.getElementById("navList").classList.toggle("show");
  });

  // Search Overlay Functions
  function openSearch() {
    document.getElementById("searchOverlay").style.display = "flex";
  }

  function closeSearch() {
    document.getElementById("searchOverlay").style.display = "none";
  }

//   ========================================================================

