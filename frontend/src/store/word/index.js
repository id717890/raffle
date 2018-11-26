import context from '../../api/word'
import * as types from '../mutation-types'
import moment from '@/packages/moment'

const state = {
  model: [],
  selectedCategoryId: null
}

// getters
const getters = {
  model: state => state.model.sort((categoryA, categoryB) => {
    return categoryA.date > categoryB.date
    // if (categoryA.order < categoryB.order) return -1
    // if (categoryA.order > categoryB.order) return 1
    // return 0
  }),
  modelIsEmpty: state => state.model === null || state.model.length === 0,
  wordsIsEmpty: (state, getters) => {
    if (!getters.modelIsEmpty) {
      // console.log(getters.selectedCategory)
      if (!getters.selectedCategory.words || getters.selectedCategory.words.length === 0) return true
    }
    return false
  },
  selectedCategory: (state, getters) => state.model.find(x => x.id === getters.selectedCategoryId),
  selectedCategoryId: state => state.selectedCategoryId
}

// actions
const actions = {
  moveToCategory ({dispatch}, data) {
    dispatch('removeWordFromCategory', { category: data.categoryFrom, word: data.word })
    dispatch('saveNewWord', {
      caption: data.word.caption,
      translate: data.word.translate,
      created_at: data.word.created_at,
      author_id: data.word.author_id,
      interpretation: data.word.interpretation,
      example: data.word.example,
      categoryId: data.categoryTo.id
    })
  },
  saveNewWord ({dispatch, commit, getters, rootGetters}, data) {
    const newItem = {}
    const timestamp = moment.newTimestamp()
    newItem.caption = data.caption
    newItem.translate = data.translate
    newItem.interpretation = data.interpretation
    newItem.example = data.example
    if (data.author_id && data.author_id !== '') {
      newItem.author_id = data.author_id
    } else {
      newItem.author_id = rootGetters['auth/getUser'].id
    }
    if (data.created_at && data.created_at !== '') {
      newItem.created_at = data.created_at
    } else {
      newItem.created_at = timestamp
    }
    newItem.updated_at = timestamp
    return new Promise((resolve, reject) => {
      dispatch('setLoading', true, {root: true})
      context.store(data.categoryId, newItem).then((x) => {
        // let words = []
        // console.log(getters.wordsIsEmpty === true)
        // if (getters.wordsIsEmpty === true) {
        //   words = [{...newItem, id: data.key}]
        // } else {
        //   words = getters.selectedCategory.words
        //   words.push({...newItem, id: data.key})
        // }
        commit(types.ADD_WORD, {categoryId: data.categoryId, word: {...newItem, id: x.key}})
        dispatch('setLoading', false, {root: true})
        resolve()
      }).catch((error) => {
        dispatch('setLoading', false, {root: true})
        reject(error, 'Ошибка при добавлении категории')
      })
    })
  },
  reciveModel ({dispatch, commit, rootGetters}) {
    dispatch('setLoading', true, {root: true})
    return new Promise((resolve, reject) => {
      // console.log(context.getAll(rootGetters['auth/getUser']))
      context.getAll(rootGetters['auth/getUser'])
        .then(x => {
          commit(types.RECIVE_CATEGORIES_WITH_WORDS, x)
          dispatch('setLoading', false, {root: true})
          resolve()
        }).catch((error) => {
          dispatch('setLoading', false, {root: true})
          reject(error, 'Ошибка при извлечении слов')
        })
      // context.getAll(rootGetters['auth/getUser'])
      //   .then((data) => {
      //     const categories = []
      //     const obj = data.val()
      //     if (obj) {
      //       Object.keys(obj).forEach(x => {
      //         categories.push({
      //           id: x,
      //           caption: obj[x].caption,
      //           order: obj[x].order,
      //           words: obj[x].words
      //         })
      //       })
      //     }
      //     resolve()
      //   })
      //   .catch(error => {
      //     dispatch('setLoading', false, {root: true})
      //     reject(error)
      //   })
    })
  },
  removeCategory ({commit}, data) {
    return new Promise((resolve, reject) => {
      commit(types.REMOVE_CATEGORY_AND_WORDS, data)
      resolve()
    })
  },
  removeWordFromCategory ({commit, rootGetters}, data) {
    return new Promise((resolve, reject) => {
      context.remove(data.category, data.word, rootGetters['auth/getUser'])
        .then(() => {
          commit(types.REMOVE_WORD, data)
          resolve()
        })
        .catch(x => reject(x))
    })
  },
  selectCategory ({commit}, payload) {
    commit(types.SELECT_CATEOGRY_WITH_WORDS, payload)
  },
  updateOrderOfCategory ({commit}, payload) {
    commit(types.UPDATE_ORDER_OF_CATEGORY_OF_WORDS, payload)
  }
}

// mutations
const mutations = {
  [types.UPDATE_ORDER_OF_CATEGORY_OF_WORDS] (state, payload) {
    state.model.find(x => x.id === payload.id).order = payload.order
  },
  [types.ADD_WORD] (state, payload) {
    // console.log(state.model)
    // console.log(payload.categoryId)
    // console.log(state.model.find(xx => xx.id === payload.categoryId))
    // const findMod = state.model.find(x => x.id === payload.categoryId)
    // if (findMod) {
    //   console.log(findMod)
    // }
    state.model.find(x => x.id === payload.categoryId).words.unshift(payload.word)
  },
  [types.RECIVE_CATEGORIES_WITH_WORDS] (state, payload) {
    state.model = payload != null ? payload : []
    state.selectedCategoryId = payload != null && payload.length > 0
      ? state.model.sort((categoryA, categoryB) => {
        if (categoryA.order < categoryB.order) return -1
        if (categoryA.order > categoryB.order) return 1
        return 0
      })[0].id
      : null
  },
  [types.SELECT_CATEOGRY_WITH_WORDS] (state, payload) {
    state.selectedCategoryId = payload
  },
  [types.REMOVE_WORD] (state, payload) {
    const categoryPos = state.model.indexOf(payload.category)
    if (categoryPos > -1) {
      if (state.model[categoryPos] && state.model[categoryPos].words) {
        const wordPos = state.model[categoryPos].words.indexOf(payload.word)
        if (wordPos > -1) {
          state.model[categoryPos].words.splice(wordPos, 1)
        }
      }
    }
  },
  [types.REMOVE_CATEGORY_AND_WORDS] (state, payload) {
    const categoryFind = state.model.find(category => category.id === payload)
    if (categoryFind !== null) {
      state.model.splice(state.model.indexOf(categoryFind), 1)
      state.selectedCategoryId = state.model.length > 0 ? state.model[0].id : null
    }
  }
}

export default {
  state,
  getters,
  actions,
  mutations,
  namespaced: true
}
