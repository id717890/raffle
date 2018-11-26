// import * as types from '../mutation-types'

const state = {
  randomAnswers: []
}

// getters
const getters = {
  getRandomAnswers: (state, getters, rootGetters) => count => {
    const randomAnswers = []
    const allCategories = rootGetters.word.model
    const allWords = []
    allCategories.forEach(category => {
      if (category.words !== null) {
        allWords.push(...category.words)
      }
    })
    if (allWords.length <= count) {
      return allWords
    } else {
      const countAllWords = allWords.length
      for (let i = 0; i < allWords.length - 1; i++) {
        randomAnswers.push(allWords[Math.floor(Math.random() * countAllWords)])
      }
      return randomAnswers
    }
  },
  getRandomInterpretations: (state, getters, rootGetters) => count => {
    const randomAnswers = []
    const allCategories = rootGetters.word.model
    const allWords = []
    allCategories.forEach(category => {
      if (category.words !== null) {
        category.words.forEach(word => {
          if (word.interpretation !== null && word.interpretation !== '') allWords.push(word)
        })
        // allWords.push(...category.words)
      }
    })
    if (allWords.length <= count) {
      return allWords
    } else {
      const countAllWords = allWords.length
      for (let i = 0; i < allWords.length - 1; i++) {
        randomAnswers.push(allWords[Math.floor(Math.random() * countAllWords)])
      }
      return randomAnswers
    }
  },
  getWordsForTrain: (state, getters, rootGetters) => (category, count) => {
    const randomWords = []
    const categoryFind = rootGetters.word.model.find(x => x.id === category.id)
    if (categoryFind !== null) {
      const countWordsOfCategory = categoryFind.words.length
      if (countWordsOfCategory <= count) {
        return categoryFind.words
      } else {
        for (let i = 0; i < count; i++) {
          randomWords.push(categoryFind.words[Math.floor(Math.random() * countWordsOfCategory)])
        }
        return randomWords
      }
    }
    // const allWords = []
    // allCategories.forEach(category => {
    //   if (category.words !== null) {
    //     allWords.push(...category.words)
    //   }
    // })
    // if (allWords.length <= count) {
    //   return allWords
    // } else {
    //   const countAllWords = allWords.length
    //   for (let i = 0; i < allWords.length - 1; i++) {
    //     randomAnswers.push(allWords[Math.floor(Math.random() * countAllWords)])
    //   }
    //   return randomAnswers
    // }
  },
  getWordsForTrainByInterpretation: (state, getters, rootGetters) => (category, count) => {
    const randomWords = []
    const categoryFind = rootGetters.word.model.find(x => x.id === category.id)
    if (categoryFind !== null) {
      const wordsOfCategory = categoryFind.words.filter(x => x.interpretation !== '' && x.interpretation !== null)
      const countWordsOfCategory = wordsOfCategory.length
      if (countWordsOfCategory <= count) {
        return wordsOfCategory
      } else {
        for (let i = 0; i < count; i++) {
          randomWords.push(wordsOfCategory[Math.floor(Math.random() * countWordsOfCategory)])
        }
        return randomWords
      }
    }
  }
}

// actions
const actions = {
  startTrain2Var ({commit, getters, dispatch}, data) {
    // dispatch('setLoading', true, {root: true})
    // const findCategory = getters['category/getById'](data.category.id)
    // console.log(rootGetters['training/getRandomAnswers'](20))
    // console.log(getters['training/getRandomAnswers'](22))
    // const s = getters.getRandomAnswers(data.count)
    // const s1 = getters.getWordsForTrain(data.category, data.count)
    // console.log(s1)
    // dispatch('setLoading', false, {root: true})
    // console.log(rootGetters['training/getRandomAnswers'](20))
  }
}

// mutations
const mutations = {
}

export default {
  state,
  getters,
  actions,
  mutations,
  namespaced: true
}
