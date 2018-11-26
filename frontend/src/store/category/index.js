// import Vue from 'vue';
import context from '../../api/category'
import * as types from '../mutation-types'
import moment from '@/packages/moment'

const state = {
  model: []
}

// getters
const getters = {
  model: state => state.model.sort((categoryA, categoryB) => {
    if (categoryA.order < categoryB.order) return -1
    if (categoryA.order > categoryB.order) return 1
    return 0
  }),
  getById: state => id => {
    return state.model.find((item) => {
      return item.id === id
    })
  },
  modelOrderByDescOrder: state => state.model.sort((categoryA, categoryB) => {
    if (categoryA.order < categoryB.order) return 1
    if (categoryA.order > categoryB.order) return -1
    return 0
  })
}
// actions
const actions = {
  get: ({ dispatch, commit, rootGetters }) => {
    dispatch('setLoading', true, {root: true})
    return new Promise((resolve, reject) => {
      context.getAll(rootGetters['auth/getUser'])
        .then((data) => {
          const categories = []
          const obj = data.val()
          if (obj) {
            Object.keys(obj).forEach(x => {
              categories.push({
                id: x,
                author_id: obj[x].author_id,
                caption: obj[x].caption,
                order: obj[x].order,
                created_at: obj[x].created_at,
                updated_at: obj[x].updated_at
              })
            })
          }
          commit(types.RECIVE_CATEGORIES, categories)
          dispatch('setLoading', false, {root: true})
          resolve()
        })
        .catch(error => {
          dispatch('setLoading', false, {root: true})
          reject(error)
        })
    })
  },
  create: ({ dispatch, commit, rootGetters }, data) => {
    const newItem = {}
    const timestamp = moment.newTimestamp()
    newItem.order = state.model.length + 1
    newItem.caption = data
    newItem.author_id = rootGetters['auth/getUser'].id
    newItem.words = null
    newItem.created_at = timestamp
    newItem.updated_at = timestamp
    return new Promise((resolve, reject) => {
      dispatch('setLoading', true, {root: true})
      context.store(newItem).then((data) => {
        commit(types.ADD_CATEGORY, {...newItem, id: data.key})
        dispatch('word/reciveModel', null, {root: true})
        dispatch('setLoading', false, {root: true})
        resolve()
      }).catch((error) => {
        dispatch('setLoading', false, {root: true})
        reject(error, 'Ошибка при добавлении категории')
      })
    })
  },
  orderUp: ({commit, getters, dispatch, rootGetters}, data) => {
    const currentOrder = data.order
    let find = getters.modelOrderByDescOrder.filter(x => x.order < currentOrder)
    if (find.length === 0) return
    if (find.length >= 1) {
      const findCategory = find[0]
      let updates = {}
      const user = rootGetters['auth/getUser']
      // category1 - категория которую нужно поднять вверх по очереди
      const category1 = {
        author_id: data.author_id,
        caption: data.caption,
        created_at: data.created_at,
        updated_at: moment.newTimestamp(),
        order: findCategory.order
      }
      // category2 - категория которую нужно опустить вниз по очереди
      const category2 = {
        author_id: findCategory.author_id,
        caption: findCategory.caption,
        created_at: findCategory.created_at,
        updated_at: moment.newTimestamp(),
        order: currentOrder
      }
      updates[ 'data/' + user.id + '/categories/' + data.id ] = category1
      updates[ 'data/' + user.id + '/categories/' + findCategory.id ] = category2
      context.update(updates).then(() => {
        commit(types.CATEGORY_UPDATE, {id: data.id, data: category1})
        dispatch('word/updateOrderOfCategory', {id: data.id, order: category1.order}, {root: true})
        commit(types.CATEGORY_UPDATE, {id: findCategory.id, data: category2})
        dispatch('word/updateOrderOfCategory', {id: findCategory.id, order: category2.order}, {root: true})
      })
    }
  },
  orderDown: ({commit, dispatch, getters, rootGetters}, data) => {
    const currentOrder = data.order
    let find = getters.model.filter(x => x.order > currentOrder)
    if (find.length === 0) return
    if (find.length >= 1) {
      const findCategory = find[0]
      let updates = {}
      const user = rootGetters['auth/getUser']
      // category1 - категория которую нужно поднять вверх по очереди
      const category1 = {
        author_id: data.author_id,
        caption: data.caption,
        created_at: data.created_at,
        updated_at: moment.newTimestamp(),
        order: findCategory.order
      }
      // category2 - категория которую нужно опустить вниз по очереди
      const category2 = {
        author_id: findCategory.author_id,
        caption: findCategory.caption,
        created_at: findCategory.created_at,
        updated_at: moment.newTimestamp(),
        order: currentOrder
      }
      updates[ 'data/' + user.id + '/categories/' + data.id ] = category1
      updates[ 'data/' + user.id + '/categories/' + findCategory.id ] = category2
      context.update(updates).then(() => {
        commit(types.CATEGORY_UPDATE, {id: data.id, data: category1})
        dispatch('word/updateOrderOfCategory', {id: data.id, order: category1.order}, {root: true})
        commit(types.CATEGORY_UPDATE, {id: findCategory.id, data: category2})
        dispatch('word/updateOrderOfCategory', {id: findCategory.id, order: category2.order}, {root: true})
      })
    }
  },
  remove: ({ dispatch, commit, rootGetters }, data) => {
    return new Promise((resolve, reject) => {
      context.remove(data, rootGetters['auth/getUser']).then((x) => {
        commit(types.REMOVE_CATEGORY, data)
        dispatch('word/removeCategory', data.id, {root: true})
        resolve()
      }).catch((x) => {
        reject(x, 'Ошибка при удалении категории')
        console.log(x)
      })
    })
  }
}

// mutations
const mutations = {
  [types.RECIVE_CATEGORIES] (state, payload) {
    state.model = payload != null ? payload : []
  },
  [types.ADD_CATEGORY] (state, payload) {
    state.model.push(payload)
  },
  [types.CATEGORY_UPDATE] (state, payload) {
    let category = state.model.find(x => x.id === payload.id)
    if (category !== null) {
      category.order = payload.data.order
      category.updated_at = payload.data.updated_at
    }
  },
  [types.REMOVE_CATEGORY] (state, payload) {
    state.model.splice(state.model.indexOf(payload), 1)
  }
}

export default {
  state,
  getters,
  actions,
  mutations,
  namespaced: true
}

// export default {
//   state: {
//     categories: [
//       {id: 1, caption: 'Повторять'},
//       {id: 2, caption: 'Не знаю'},
//       {id: 3, caption: 'Знаю'}
//     ]
//   },
//   mutations: {
//   },
//   actions: {
//   },
//   getters: {
//     getAllCategories: state => {
//       return state.categories
//     }
//   }
// }
