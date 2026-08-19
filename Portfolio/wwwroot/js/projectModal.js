let previousFocus;
let dotNetReference;

const focusableElements = dialog => [...dialog.querySelectorAll(
    'a[href], button:not([disabled]), input:not([disabled]), select:not([disabled]), textarea:not([disabled]), [tabindex]:not([tabindex="-1"])'
)];

function onKeyDown(event) {
    const dialog = document.querySelector('.project-image-viewer[role="dialog"]')
        ?? document.querySelector('.project-modal[role="dialog"]');
    if (!dialog) return;
    if (event.key === 'Escape') {
        event.preventDefault();
        dotNetReference?.invokeMethodAsync('CloseFromJavaScript');
        return;
    }
    if (event.key !== 'Tab') return;
    const elements = focusableElements(dialog);
    if (!elements.length) { event.preventDefault(); return; }
    const first = elements[0];
    const last = elements[elements.length - 1];
    if (event.shiftKey && document.activeElement === first) {
        event.preventDefault(); last.focus();
    } else if (!event.shiftKey && document.activeElement === last) {
        event.preventDefault(); first.focus();
    }
}

export function open(reference) {
    previousFocus = document.activeElement;
    dotNetReference = reference;
    document.addEventListener('keydown', onKeyDown);
    document.body.style.overflow = 'hidden';
    document.querySelector('.project-modal-close')?.focus();
}

export function focusImageViewer() {
    document.querySelector('.project-image-viewer-close')?.focus();
}

export function close() {
    document.removeEventListener('keydown', onKeyDown);
    document.body.style.overflow = '';
    previousFocus?.focus();
    previousFocus = undefined;
    dotNetReference = undefined;
}
