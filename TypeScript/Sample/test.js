function Zoo(a) {
    console.log(`a=${a}`);
    console.log(arguments);
} 

Zoo(100, 'Hello', new Date());