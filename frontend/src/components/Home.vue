<template>
  <b-container fluid class="p-0" style="height: 100%">
    <b-row class="p-0"  style="height: 100%">
      <b-col class="p-0" style="height: 100%">
        <div class="prblock1 prlx"></div>
        <div class="txt">
          <h3 style="text-align:center;">Parallax Demo</h3>
          <p>Parallax scrolling is a web site trend where the background content is moved at a different speed than the foreground content while scrolling. Nascetur per nec posuere turpis, lectus nec libero turpis nunc at, sed posuere mollis ullamcorper libero ante lectus, blandit pellentesque a, magna turpis est sapien duis blandit dignissim. Viverra interdum mi magna mi, morbi sociis. Condimentum dui ipsum consequat morbi, curabitur aliquam pede, nullam vitae eu placerat eget et vehicula. Varius quisque non molestie dolor, nunc nisl dapibus vestibulum at, sodales tincidunt mauris ullamcorper, dapibus pulvinar, in in neque risus odio. Accumsan fringilla vulputate at quibusdam sociis eleifend, aenean maecenas vulputate, non id vehicula lorem mattis, ratione interdum sociis ornare. Suscipit proin magna cras vel, non sit platea sit, maecenas ante augue etiam maecenas, porta porttitor placerat leo.</p>
        </div>
        <div class="prblock2 prlx"></div>
        <div class="txt" style="min-height: 700px">
          <h3 style="text-align:center;">Parallax Demo</h3>
          <p>Parallax scrolling is a web site trend where the background content is moved at a different speed than the foreground content while scrolling. Nascetur per nec posuere turpis, lectus nec libero turpis nunc at, sed posuere mollis ullamcorper libero ante lectus, blandit pellentesque a, magna turpis est sapien duis blandit dignissim. Viverra interdum mi magna mi, morbi sociis. Condimentum dui ipsum consequat morbi, curabitur aliquam pede, nullam vitae eu placerat eget et vehicula. Varius quisque non molestie dolor, nunc nisl dapibus vestibulum at, sodales tincidunt mauris ullamcorper, dapibus pulvinar, in in neque risus odio. Accumsan fringilla vulputate at quibusdam sociis eleifend, aenean maecenas vulputate, non id vehicula lorem mattis, ratione interdum sociis ornare. Suscipit proin magna cras vel, non sit platea sit, maecenas ante augue etiam maecenas, porta porttitor placerat leo.</p>
        </div>
        <div class="prblock3 prlx"></div>
      </b-col>
    </b-row>
  </b-container>
</template>

<style>
  .prblock1 {
    /* Set a specific height */
    min-height: 100%; 
    background-image: url('https://www.w3schools.com/howto/img_parallax.jpg');    
  }

  .txt {
    color: #777;
    background-color: white;
    text-align: center;
    padding: 50px 80px;
    text-align: justify;
  }

  .prlx {
    /* Create the parallax scrolling effect */
    background-attachment: fixed;
    background-position: center;
    background-repeat: no-repeat;
    background-size: cover;
  }

  .prblock2 {
    background-image: url('https://www.w3schools.com/howto/img_parallax2.jpg');
    /* Set a specific height */
    min-height: 100%; 
  }

  .prblock3 {
    background-image: url('https://www.w3schools.com/howto/img_parallax3.jpg');
    min-height: 100%; 
  }

  html, body {
    height: 100% !important;
  }
</style>
