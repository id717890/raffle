const colort = [
  'red',
  'pink',
  'purple',
  'deep-purple',
  'indigo',
  'blue',
  'light-blue',
  'cyan',
  'teal',
  'green',
  'light-green',
  'lime',
  'amber',
  'yellow',
  'orange',
  'deep-orange',
  'brown',
  'blue-grey',
  'grey'
]

export default {
  getRandomColor () {
    return colort[Math.floor(Math.random() * colort.length)]
  }
}
