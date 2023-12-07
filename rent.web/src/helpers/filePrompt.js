export default (contentType, multiple) => {
  let input = document.createElement('input')
  input.type = 'file'
  input.multiple = multiple
  input.accept = contentType
  return new Promise(function (resolve) {
    document.activeElement.onfocus = function () {
      document.activeElement.onfocus = null
      setTimeout(resolve, 500)
    }
    input.onchange = function () {
      let files = Array.from(input.files)
      if (multiple) return resolve(files)
      resolve(files[0])
    }
    input.click()
  })
}
