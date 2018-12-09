<template>
  <b-container fluid class="p-0 m-0 w-100">
    <h2 class="mb-5">Настройки пользователя</h2>
    <b-row>
      <b-col lg="6" offset-lg="3">
        <b-row>
          <b-col cols="12" class="text-left">
            <label for="firstName">Имя</label>
          </b-col>
        </b-row>
        <b-row class="mb-4">
          <b-col cols="12">
            <b-form-input id="firstName" type="text"></b-form-input>
          </b-col>
        </b-row>
        <b-row>
          <b-col cols="12" class="text-left">
            <label for="lasttName">Фамилия</label>
          </b-col>
        </b-row>
        <b-row class="mb-4">
          <b-col cols="12">
            <b-form-input id="lasttName" type="text"></b-form-input>
          </b-col>
        </b-row>
        <b-row>
          <b-col cols="12" class="text-left">
            <label for="address">Адрес</label>
          </b-col>
        </b-row>
        <b-row>
          <b-col cols="12">
            <b-form-input id="address" type="text"></b-form-input>
          </b-col>
        </b-row>
      </b-col>
    </b-row>
    

  </b-container>
</template>

<script>
export default {

}
</script>

<style>

</style>
