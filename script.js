// Mobile Navigation Toggle
const hamburger = document.getElementById('hamburger');
const nav = document.getElementById('nav');

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
let currentSlideIndex = 0;
const slides = document.querySelectorAll('.slide');
const dots = document.querySelectorAll('.dot');

function showSlide(index) {
    slides.forEach(slide => slide.classList.remove('active'));
    dots.forEach(dot => dot.classList.remove('active'));
    
    if (slides[index]) {
        slides[index].classList.add('active');
    }
    if (dots[index]) {
        dots[index].classList.add('active');
    }
}

function changeSlide(direction) {
    currentSlideIndex += direction;
    if (currentSlideIndex >= slides.length) {
        currentSlideIndex = 0;
    }
    if (currentSlideIndex < 0) {
        currentSlideIndex = slides.length - 1;
    }
    showSlide(currentSlideIndex);
}

function currentSlide(index) {
    currentSlideIndex = index - 1;
    showSlide(currentSlideIndex);
}

// Auto-play slider
if (slides.length > 0) {
    setInterval(() => {
        changeSlide(1);
    }, 5000);
}

// Search Overlay
function toggleSearch() {
    const searchOverlay = document.getElementById('searchOverlay');
    if (searchOverlay) {
        searchOverlay.style.display = searchOverlay.style.display === 'flex' ? 'none' : 'flex';
    }
}

// Job Form Submission
const jobForm = document.getElementById('jobForm');
if (jobForm) {
    jobForm.addEventListener('submit', (e) => {
        e.preventDefault();
        
        const formData = new FormData(jobForm);
        const submitBtn = jobForm.querySelector('.submit-btn');
        
        // Simulate form submission
        submitBtn.innerHTML = '<i class="fas fa-spinner fa-spin"></i> Submitting...';
        submitBtn.disabled = true;
        
        setTimeout(() => {
            alert('Application submitted successfully! We will review your application and get back to you within 5-7 business days.');
            jobForm.reset();
            submitBtn.innerHTML = '<i class="fas fa-paper-plane"></i> Submit Application';
            submitBtn.disabled = false;
        }, 2000);
    });
}

// File Upload Handler
const fileInput = document.getElementById('resume');
if (fileInput) {
    fileInput.addEventListener('change', (e) => {
        const file = e.target.files[0];
        const label = document.querySelector('.file-upload-label span');
        
        if (file) {
            if (file.size > 5 * 1024 * 1024) { // 5MB limit
                alert('File size should be less than 5MB');
                e.target.value = '';
                return;
            }
            label.textContent = file.name;
        } else {
            label.textContent = 'Choose file or drag and drop';
        }
    });
}

// Subscription Plan Selection
function selectPlan(planType, price) {
    const modal = document.getElementById('paymentModal');
    const planNameElement = document.getElementById('selectedPlanName');
    const planPriceElement = document.getElementById('selectedPlanPrice');
    const paymentAmountElement = document.getElementById('paymentAmount');
    const qrCodeImage = document.getElementById('qrCodeImage');
    
    if (modal && planNameElement && planPriceElement) {
        // Update plan details
        planNameElement.textContent = planType.charAt(0).toUpperCase() + planType.slice(1) + ' Plan';
        planPriceElement.textContent = price;
        paymentAmountElement.textContent = price;
        
        // Update QR code with new amount
        const upiUrl = `upi://pay?pa=shinetheworld@paytm&pn=Shine%20the%20World&am=${price}&cu=INR`;
        qrCodeImage.src = `https://api.qrserver.com/v1/create-qr-code/?size=200x200&data=${encodeURIComponent(upiUrl)}`;
        
        // Show modal
        modal.style.display = 'flex';
    }
}

function closePaymentModal() {
    const modal = document.getElementById('paymentModal');
    if (modal) {
        modal.style.display = 'none';
    }
}

// Payment Method Toggle
const paymentMethodRadios = document.querySelectorAll('input[name="paymentMethod"]');
paymentMethodRadios.forEach(radio => {
    radio.addEventListener('change', (e) => {
        const upiPayment = document.getElementById('upiPayment');
        const cardPayment = document.getElementById('cardPayment');
        
        if (e.target.value === 'upi') {
            upiPayment.style.display = 'block';
            cardPayment.style.display = 'none';
        } else {
            upiPayment.style.display = 'none';
            cardPayment.style.display = 'block';
        }
    });
});

// UPI App Integration
function openUPIApp(app) {
    const amount = document.getElementById('paymentAmount').textContent;
    const upiId = 'shinetheworld@paytm';
    const merchantName = 'Shine the World';
    
    let upiUrl = `upi://pay?pa=${upiId}&pn=${merchantName}&am=${amount}&cu=INR`;
    
    // Try to open UPI app
    window.location.href = upiUrl;
    
    // Fallback for web browsers
    setTimeout(() => {
        alert(`Please open your ${app} app and scan the QR code to complete the payment.`);
    }, 1000);
}

// Payment Verification
function verifyPayment() {
    const verifyBtn = document.querySelector('.verify-payment-btn');
    
    verifyBtn.innerHTML = '<i class="fas fa-spinner fa-spin"></i> Verifying...';
    verifyBtn.disabled = true;
    
    setTimeout(() => {
        alert('Payment verified successfully! Welcome to Shine the World Premium. You now have access to all premium features.');
        closePaymentModal();
        verifyBtn.innerHTML = '<i class="fas fa-check-circle"></i> I have completed the payment';
        verifyBtn.disabled = false;
    }, 3000);
}

// Card Form Handling
const cardForm = document.querySelector('.card-form');
if (cardForm) {
    cardForm.addEventListener('submit', (e) => {
        e.preventDefault();
        
        const payBtn = cardForm.querySelector('.pay-now-btn');
        payBtn.innerHTML = '<i class="fas fa-spinner fa-spin"></i> Processing...';
        payBtn.disabled = true;
        
        setTimeout(() => {
            alert('Payment processed successfully! Welcome to Shine the World Premium.');
            closePaymentModal();
            payBtn.innerHTML = '<i class="fas fa-lock"></i> Pay Securely';
            payBtn.disabled = false;
        }, 3000);
    });
}

// Card Number Formatting
const cardNumberInput = document.getElementById('cardNumber');
if (cardNumberInput) {
    cardNumberInput.addEventListener('input', (e) => {
        let value = e.target.value.replace(/\s/g, '').replace(/[^0-9]/gi, '');
        let formattedValue = value.match(/.{1,4}/g)?.join(' ') || value;
        e.target.value = formattedValue;
    });
}

// Expiry Date Formatting
const expiryInput = document.getElementById('expiryDate');
if (expiryInput) {
    expiryInput.addEventListener('input', (e) => {
        let value = e.target.value.replace(/\D/g, '');
        if (value.length >= 2) {
            value = value.substring(0, 2) + '/' + value.substring(2, 4);
        }
        e.target.value = value;
    });
}

// Search functionality
const searchBtn = document.querySelector('.search-btn');
const searchInput = document.querySelector('.search-input');

if (searchBtn) {
    searchBtn.addEventListener('click', () => {
        const searchQuery = searchInput ? searchInput.value.trim() : '';
        if (searchQuery) {
            alert(`Searching for: "${searchQuery}"\n\nIn a real implementation, this would redirect to search results.`);
        }
    });
}

if (searchInput) {
    searchInput.addEventListener('keypress', (e) => {
        if (e.key === 'Enter') {
            const searchQuery = searchInput.value.trim();
            if (searchQuery) {
                alert(`Searching for: "${searchQuery}"\n\nIn a real implementation, this would redirect to search results.`);
            }
        }
    });
}

// Logout function
function logout() {
    if (confirm('Are you sure you want to logout?')) {
        alert('You have been logged out successfully.');
        // In a real implementation, this would clear session and redirect
    }
}

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

// Add loading animation for images
const images = document.querySelectorAll('img');
images.forEach(img => {
    img.addEventListener('load', () => {
        img.style.opacity = '1';
    });
    
    img.addEventListener('error', () => {
        img.style.opacity = '0.5';
        img.alt = 'Image failed to load';
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

// Keyboard navigation support
document.addEventListener('keydown', (e) => {
    // ESC key closes modals and mobile menu
    if (e.key === 'Escape') {
        if (hamburger && nav) {
            hamburger.classList.remove('active');
            nav.classList.remove('active');
        }
        
        const searchOverlay = document.getElementById('searchOverlay');
        if (searchOverlay && searchOverlay.style.display === 'flex') {
            toggleSearch();
        }
        
        const paymentModal = document.getElementById('paymentModal');
        if (paymentModal && paymentModal.style.display === 'flex') {
            closePaymentModal();
        }
    }
    
    // Arrow keys for slider navigation
    if (slides.length > 0) {
        if (e.key === 'ArrowLeft') {
            changeSlide(-1);
        } else if (e.key === 'ArrowRight') {
            changeSlide(1);
        }
    }
});

// Initialize page
document.addEventListener('DOMContentLoaded', () => {
    console.log('Shine the World News Portal loaded successfully');
    
    // Add smooth fade-in for hero section
    const hero = document.querySelector('.hero');
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

// Click outside modal to close
window.addEventListener('click', (e) => {
    const paymentModal = document.getElementById('paymentModal');
    if (e.target === paymentModal) {
        closePaymentModal();
    }
    
    const searchOverlay = document.getElementById('searchOverlay');
    if (e.target === searchOverlay) {
        toggleSearch();
    }
});

// Form validation helpers
function validateEmail(email) {
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailRegex.test(email);
}

function validatePhone(phone) {
    const phoneRegex = /^[0-9]{10}$/;
    return phoneRegex.test(phone.replace(/\D/g, ''));
}

// Add real-time form validation
const formInputs = document.querySelectorAll('input[required], select[required], textarea[required]');
formInputs.forEach(input => {
    input.addEventListener('blur', () => {
        if (!input.value.trim()) {
            input.style.borderColor = '#ef4444';
        } else {
            input.style.borderColor = '#16a34a';
        }
    });
    
    input.addEventListener('input', () => {
        if (input.value.trim()) {
            input.style.borderColor = '#e2e8f0';
        }
    });
});

// Add click tracking for analytics
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

// Newsletter subscription (if present on page)
const newsletterForms = document.querySelectorAll('.newsletter-form');
newsletterForms.forEach(form => {
    form.addEventListener('submit', (e) => {
        e.preventDefault();
        
        const emailInput = form.querySelector('input[type="email"]');
        const submitBtn = form.querySelector('button[type="submit"]');
        const email = emailInput.value.trim();
        
        if (email && validateEmail(email)) {
            submitBtn.textContent = 'Subscribing...';
            submitBtn.disabled = true;
            
            setTimeout(() => {
                submitBtn.textContent = 'Subscribed!';
                emailInput.value = '';
                
                setTimeout(() => {
                    submitBtn.textContent = 'Subscribe';
                    submitBtn.disabled = false;
                }, 2000);
            }, 2000);
        } else {
            alert('Please enter a valid email address');
        }
    });
});