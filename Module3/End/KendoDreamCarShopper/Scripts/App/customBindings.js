//Adapted from code in the Kendo Music Store application
//https://github.com/telerik/kendo-music-store

kendo.data.binders.imageSlider = kendo.data.Binder.extend({
    init: function (element, bindings, options) {
        kendo.data.Binder.fn.init.call(this, element, bindings, options);
        var binding = this.bindings.imageSlider;
        var target = $(element);
        binding.slideDelay = target.data("slide-delay");
        binding.imageIndex = 0;
        binding.slideImage = function () {
            var imageArray = binding.get();
            var nextImageUrl = imageArray[binding.imageIndex].LowResolutionUrl;

            kendo.fx(target).fadeOut().play().then(function () {
                target.attr("src", nextImageUrl);
                kendo.fx(target).fadeIn().play();
            });

            binding.imageIndex++;
            if (binding.imageIndex >= imageArray.length) {
                binding.imageIndex = 0;
            }
        };
    },
    refresh: function () {
        var binding = this.bindings.imageSlider;
        binding.imageIndex = 0;
        binding.slideImage();
        binding.interval = setInterval(binding.slideImage, binding.slideDelay);
    },
    destroy: function () {
        var binding = this.bindings.imageSlider;
        clearInterval(binding.interval);
    }
});