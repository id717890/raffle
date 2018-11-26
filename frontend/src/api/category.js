import config from '@/packages/config'
import * as firebase from 'firebase'

let data = {
  val () {
    return [
      {id: 111, caption: 'Repeat', order: 1},
      {id: 333, caption: 'Dont know', order: 3},
      {id: 222, caption: 'Know', order: 2}
    ]
  }
}

export default {
  getAll: (user) => {
    if (config.isLocalApp()) {
      return new Promise((resolve) => { resolve(data) })
    }
    return firebase.database().ref('data/' + user.id + '/categories').once('value')
  },
  store: (item) => {
    if (config.isLocalApp()) {
      const newItem = {
        ...item,
        id: Math.floor(Math.random() * 1000)
      }
      return new Promise((resolve) => {
        resolve(newItem)
      })
    }
    return firebase.database().ref('data/' + item.author_id + '/categories').push(item)
  },
  remove: (category, user) => {
    if (config.isLocalApp()) {
      return new Promise((resolve, reject) => {
        resolve({category})
      })
    }
    const ref = 'data/' + user.id
    return firebase.database().ref(ref + '/words/' + category.id).remove().then(() => {
      firebase.database().ref(ref + '/categories/' + category.id).remove()
    })
  },
  update: (updates) => {
    return firebase.database().ref().update(updates)
  }
}
