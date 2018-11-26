import config from '@/packages/config'
import * as firebase from 'firebase'

let data = [
  {
    id: 111,
    caption: 'Repeat',
    order: 1,
    words: [
      {id: 1, caption: 'humanity', translate: 'человечество', example: 'example 1', created_at: '2018-01-01 18:00:00', updated_at: '2018-01-01  18:00:00', interpretation: 'Mankind'},
      {id: 2, caption: 'almost', translate: 'почти', example: 'Almos all people went there', created_at: '2018-01-01 19:00:00', updated_at: '2018-01-01  19:00:00', interpretation: 'Very close to, but not quite'},
      {id: 3, caption: 'unlike', translate: 'в отличии от', example: '', created_at: '2018-01-01 19:00:00', updated_at: '2018-01-01  19:00:00', interpretation: 'Not like; Unequal'},
      {id: 4, caption: 'reflection', translate: 'отражение', example: '', created_at: '2018-01-01 19:00:00', updated_at: '2018-01-01  19:00:00', interpretation: 'The act of reflecting or the state of being reflected rqerqwerq qwer qwer q'},
      {id: 5, caption: 'toward', translate: 'в направлении', example: 'She moved toward the door', created_at: '2018-01-01 19:00:00', updated_at: '2018-01-01  19:00:00', interpretation: 'In the direction of'},
      {id: 6, caption: 'convey', translate: 'передавать', example: 'Air conveyes sounds', created_at: '2018-01-01 19:00:00', updated_at: '2018-01-01  19:00:00', interpretation: 'To move from one place to another'},
      {id: 7, caption: 'salary', translate: 'зарплата', example: 'This is hire and salary, not revenge', created_at: '2018-01-01 19:00:00', updated_at: '2018-01-01  19:00:00', interpretation: 'A fixed amount of money paid to a worker'},
      {id: 8, caption: 'venturing', translate: 'углубляться', example: '', created_at: '2018-01-01 19:00:00', updated_at: '2018-01-01  19:00:00', interpretation: 'The act of one who ventures'},
      {id: 9, caption: 'daunting', translate: 'пугающий', example: '', created_at: '2018-01-01 19:00:00', updated_at: '2018-01-01  19:00:00', interpretation: 'Discouraging, inspiring fear'},
      {id: 10, caption: 'maintain', translate: 'поддерживать', example: '', created_at: '2018-01-01 19:00:00', updated_at: '2018-01-01  19:00:00', interpretation: 'To support; to back up or assist'},
      {id: 11, caption: 'correspond', translate: 'соответствовать', example: '', created_at: '2018-01-01 19:00:00', updated_at: '2018-01-01  19:00:00', interpretation: 'To be equivalent or similar'},
      {id: 12, caption: 'I have a bad feeling about this', translate: 'У меня плохое предчувствие на счет этого', example: '', created_at: '2018-01-01 19:00:00', updated_at: '2018-01-01  19:00:00', interpretation: ''}
    ]},
  {
    id: 222,
    caption: 'Know',
    order: 2,
    words: [
      {id: 12, caption: 'tree', translate: 'дерево', example: 'There are trees in the garden', created_at: '2018-01-02 18:00:00', updated_at: '2018-01-02  18:00:00', interpretation: 'A large plant'}
    ]},
  {
    id: 333,
    caption: 'Dont know',
    order: 3,
    words: [
      {id: 14, caption: 'not at all', translate: 'совсем нет', example: '', created_at: '2018-01-04 18:00:00', updated_at: '2018-01-04  18:00:00', interpretation: ''},
      {id: 13, caption: 'obviously', translate: 'очевидно', example: '', created_at: '2018-01-03 11:00:00', updated_at: '2018-01-03  11:00:00', interpretation: 'Clearly apparent'}
    ]}
]

export default {
  getAll: (user) => {
    if (config.isLocalApp()) {
      return new Promise((resolve) => { resolve(data) })
    }
    let words = []
    const categoriesOfWords = []
    return new Promise((resolve) => {
      firebase.database().ref('data/' + user.id + '/categories').once('value')
        .then((result) => {
          const obj = result.val()
          if (obj) {
            Object.keys(obj).forEach(x => {
              const newCategoryWord = {
                id: x,
                caption: obj[x].caption,
                order: obj[x].order,
                words: []
              }
              firebase.database().ref('data/' + user.id + '/words/' + newCategoryWord.id).orderByChild('updated_at').once('value')
                .then(rWords => {
                  const objWords = rWords.val()
                  if (objWords) {
                    Object.keys(objWords).forEach(xWord => {
                      const newWord = {
                        id: xWord,
                        caption: objWords[xWord].caption,
                        translate: objWords[xWord].translate,
                        interpretation: objWords[xWord].interpretation,
                        example: objWords[xWord].example,
                        author_id: objWords[xWord].author_id,
                        created_at: objWords[xWord].created_at,
                        updated_at: objWords[xWord].updated_at
                      }
                      words.push(newWord)
                    })
                    newCategoryWord.words = words.reverse()
                    words = []
                  }
                })
              categoriesOfWords.push(newCategoryWord)
            })
          }
          resolve(categoriesOfWords)
        })
    })
    // return categoriesOfWords
    // return firebase.database().ref('data/' + user.id + '/categories').once('value')
  },
  store: (categoryId, item) => {
    if (config.isLocalApp()) {
      const newItem = {
        ...item,
        id: Math.floor(Math.random() * 1000)
      }
      return new Promise((resolve) => {
        resolve(newItem)
      })
    }
    return firebase.database().ref('data/' + item.author_id + '/words/' + categoryId).push(item)
  },
  remove: (category, word, user) => {
    if (config.isLocalApp()) {
      return new Promise((resolve, reject) => resolve())
    }
    const ref = 'data/' + user.id + '/words/' + category.id + '/' + word.id
    return firebase.database().ref(ref).remove()
    // return new Promise((resolve, reject) => {
    //   const findCategory = data.find(category => category.id === categoryId)
    //   console.log(findCategory)
    //   if (findCategory && findCategory.words) {
    //     console.log('ok')
    //   }
    //   resolve()
    // })
  }
}
