/** @type {import('tailwindcss').Config} */
module.exports = {
    content: ["./**/*.{html,fs}"],
    theme: {
        extend: {},
    },
    plugins: [require('daisyui')],
    daisyui: {
        themes: ["light"]
    }
}
