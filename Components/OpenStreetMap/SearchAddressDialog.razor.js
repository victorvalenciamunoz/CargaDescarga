export function modifyDialogStyle() {
    const dialog = document.querySelector('fluent-dialog');
    if (dialog) {
        const controlElement = dialog.shadowRoot.querySelector('[part="control"]');
        if (controlElement) {
            controlElement.style.margin = '35px';
            controlElement.style.boxShadow = '5px 5px 50px #0080E2';
            controlElement.style.border = '2px solid #363B83';
            controlElement.style.backgroundColor = "rgba(2, 4, 36, 1)";
        }
    }
}
