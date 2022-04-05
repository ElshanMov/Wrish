let editor;
ClassicEditor
    .create(document.querySelector('#editor'), {
        toolbar: ['heading', '|', 'bold', 'italic', 'link', 'bulletedList', 'numberedList', 'blockQuote', 'link']
    })
    .then(newEditor => {
        editor = newEditor;
    })
    .catch(error => {
        console.error(error);
    });
$(function () {
    document.getElementById("createForm").onsubmit = function (e) {
        let editor = document.querySelector(".ck-content");
        let textarea = document.getElementById("Text");
        alert("P content : " + editor.innerHTML)
        textarea.value = editor.innerText;
        alert(textarea.value)
    }
})